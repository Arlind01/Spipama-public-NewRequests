using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spipama.Domain.Context;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Interfaces;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class OverviewRepository : IOverviewRepository
    {

        private readonly SpipamaPublicWebDbContext context;
        private readonly IMeasureRepository measureRepository;
        private readonly IMapper mapper;

        public OverviewRepository(SpipamaPublicWebDbContext context, IMeasureRepository measureRepository, IMapper mapper)
        {
            this.context = context;
            this.measureRepository = measureRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ActionPlan>> GetActionPlans()
        {
            var result = await context.ActionPlans.Where(y => y.IsDeleted == false && y.Status == 1).OrderByDescending(x => x.CreatedOn).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ImplementationOfMeasurePerInstitutionDTO>> GetOverviewOfImplementationMeasurePerInstitution(Guid actionPlanId)
        {

            List<ImplementationOfMeasurePerInstitutionDTO> measurePerInstitutionDTO = new List<ImplementationOfMeasurePerInstitutionDTO>();
            var objectiveStrategics = await context.ObjectiveStrategics.Where(x => x.ActionPlanId == actionPlanId && x.IsDeleted == false).ToListAsync();
            List<MeasureWithDetailsDTO> measures = new List<MeasureWithDetailsDTO>();
            List<Institution> institutions = new List<Institution>();
            ImplementationOfMeasurePerInstitutionDTO implementationOfMeasurePerInstitutionDTO = new ImplementationOfMeasurePerInstitutionDTO();

            foreach (var objectiveStrategic in objectiveStrategics)
            {
                var objectiveSpecifics = await context.ObjectiveSpecifics.Where(x => x.ObjectiveStrategicId == objectiveStrategic.Id && x.IsDeleted == false).ToListAsync();
                foreach (var objectiveSpecific in objectiveSpecifics)
                {
                    measures.AddRange(await measureRepository.GetMeasureDetails(objectiveSpecific.Id));
                }
            }

            Institution institution = null;

            foreach (var measure in measures.OrderBy(x => x.ResponsibleInstitution.Name))
            {

                int nrOfMeasures = 0;
                int count = 0;
                int countNotImp = 0;


                if (institution != measure.ResponsibleInstitution || institution == null)
                {
                    institution = measure.ResponsibleInstitution;
                    nrOfMeasures++;
                    if (measure.Status == 1)
                    {
                        count++;
                    }
                    else
                    {
                        countNotImp++;
                    }

                    implementationOfMeasurePerInstitutionDTO = new ImplementationOfMeasurePerInstitutionDTO()
                    {
                        ActionPlanId = actionPlanId,
                        Institution = mapper.Map<InstitutionDTO>(institution),
                        NumberOfMeasures = countNotImp,
                        NumberOfImplementedMeasures = count
                    };

                    measurePerInstitutionDTO.Add(implementationOfMeasurePerInstitutionDTO);
                }
                else
                {
                    institution = measure.ResponsibleInstitution;
                    nrOfMeasures++;
                    if (measure.Status == 1)
                    {
                        count++;
                    }
                    else
                    {
                        countNotImp++;
                    }

                    implementationOfMeasurePerInstitutionDTO.ActionPlanId = actionPlanId;
                    implementationOfMeasurePerInstitutionDTO.Institution = mapper.Map<InstitutionDTO>(institution);
                    implementationOfMeasurePerInstitutionDTO.NumberOfMeasures += countNotImp;
                    implementationOfMeasurePerInstitutionDTO.NumberOfImplementedMeasures += count;
                }
            }

            return measurePerInstitutionDTO.OrderByDescending(x => x.NumberOfMeasures);
        }

        public async Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTO>> GetOverviewOfImplementationMeasurePerPerObjectiveStrategic(Guid actionPlanId)
        {
            List<ImplementationOfMeasurePerObjectiveDTO> perObjectiveStrategicDTOs = new List<ImplementationOfMeasurePerObjectiveDTO>();
            var objectiveStrategics = await context.ObjectiveStrategics.Where(x => x.ActionPlanId == actionPlanId && x.IsDeleted == false).ToListAsync();
            ImplementationOfMeasurePerObjectiveDTO implementationOfMeasurePerObjectiveStrategic = new ImplementationOfMeasurePerObjectiveDTO();

            foreach (var objectiveStrategic in objectiveStrategics)
            {
                var objectiveSpecifics = await context.ObjectiveSpecifics.Where(x => x.ObjectiveStrategicId == objectiveStrategic.Id && x.IsDeleted == false).ToListAsync();
                List<MeasureWithDetailsDTO> measures = new List<MeasureWithDetailsDTO>();

                foreach (var objectiveSpecific in objectiveSpecifics)
                {
                    measures.AddRange(await measureRepository.GetMeasureDetails(objectiveSpecific.Id));
                }
                int nrOfMeasures = 0;
                int count = 0;

                nrOfMeasures = measures.Count;
                count = measures.Where(x => x.Status == 1).ToList().Count;

                implementationOfMeasurePerObjectiveStrategic = new ImplementationOfMeasurePerObjectiveDTO()
                {
                    ActionPlanId = actionPlanId,
                    //ObjectiveIdentifier = "Objektiva " + objectiveStrategic.Identifier,
                    ObjectiveIdentifier = objectiveStrategic.Name,
                    NumberOfMeasures = nrOfMeasures,
                    NumberOfImplementedMeasures = count
                };

                perObjectiveStrategicDTOs.Add(implementationOfMeasurePerObjectiveStrategic);
            }

            return perObjectiveStrategicDTOs;
        }

        public async Task<ImplementationPieChartDTO> GetOverviewOfImplementationOfIndicators(Guid actionPlanId)
        {
            var objectiveStrategics = await context.ObjectiveStrategics.Where(x => x.ActionPlanId == actionPlanId && x.IsDeleted == false).ToListAsync();
            ImplementationPieChartDTO implementationOfIndicators = new ImplementationPieChartDTO();
            int implemented = 0;
            int allIndicators = 0;
            List<IndicatorStrategic> indicatorStrategics = new List<IndicatorStrategic>();
            List<IndicatorSpecific> indicatorSpecifics = new List<IndicatorSpecific>();
            byte[] impIndicatorDoc = null;
            byte[] notImpIndicatorDoc = null;

            foreach (var objectiveStrategic in objectiveStrategics)
            {

                var objectiveSpecifics = await context.ObjectiveSpecifics.Where(x => x.ObjectiveStrategicId == objectiveStrategic.Id && x.IsDeleted == false).ToListAsync();
                indicatorStrategics.AddRange(await context.IndicatorStrategics.Where(x => x.ObjectiveStrategicId == objectiveStrategic.Id && x.IsDeleted == false).ToListAsync());

                foreach (var objectiveSpecific in objectiveSpecifics)
                {
                    indicatorSpecifics.AddRange(await context.IndicatorSpecifics.Where(x => x.ObjectiveSpecificId == objectiveSpecific.Id && x.IsDeleted == false).ToListAsync());
                }
            }


            allIndicators += indicatorStrategics.Count + indicatorSpecifics.Count;
            implemented += indicatorStrategics.Where(x => x.IndicatorStatusId == 1 || x.IndicatorStatusId == 3).ToList().Count + indicatorSpecifics.Where(x => x.IndicatorStatusId == 1 || x.IndicatorStatusId == 3).ToList().Count;
            
            impIndicatorDoc = CreateIndicatorDoc(indicatorSpecifics.Where(x => x.IndicatorStatusId == 1 || x.IndicatorStatusId == 3).ToList(), indicatorStrategics.Where(x => x.IndicatorStatusId == 1 || x.IndicatorStatusId == 3).ToList());
            notImpIndicatorDoc = CreateIndicatorDoc(indicatorSpecifics.Where(x => x.IndicatorStatusId == 2 || x.IndicatorStatusId == 4).ToList(), indicatorStrategics.Where(x => x.IndicatorStatusId == 2 || x.IndicatorStatusId == 4).ToList());

            implementationOfIndicators = new ImplementationPieChartDTO()
            {
                ActionPlanId = actionPlanId,
                Implemented = implemented,
                NotImplemented = allIndicators - implemented,
                ImpDoc = impIndicatorDoc,
                NotImpDoc = notImpIndicatorDoc
            };

            return implementationOfIndicators;
        }

        public async Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTO>> GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(Guid actionPlanId)
        {
            List<ImplementationOfMeasurePerObjectiveDTO> perObjectiveSpecificDTOs = new List<ImplementationOfMeasurePerObjectiveDTO>();
            var objectiveStrategics = await context.ObjectiveStrategics.Where(x => x.ActionPlanId == actionPlanId && x.IsDeleted == false).ToListAsync();
            ImplementationOfMeasurePerObjectiveDTO implementationOfMeasurePerObjectiveSpecific = new ImplementationOfMeasurePerObjectiveDTO();

            foreach (var objectiveStrategic in objectiveStrategics)
            {
                var objectiveSpecifics = await context.ObjectiveSpecifics.Where(x => x.ObjectiveStrategicId == objectiveStrategic.Id && x.IsDeleted == false).ToListAsync();
                List<MeasureWithDetailsDTO> measures = new List<MeasureWithDetailsDTO>();

                foreach (var objectiveSpecific in objectiveSpecifics)
                {
                    measures = await measureRepository.GetMeasureDetails(objectiveSpecific.Id);

                    int nrOfMeasures = 0;
                    int count = 0;

                    nrOfMeasures = measures.Count;
                    count = measures.Where(x => x.Status == 1).ToList().Count;

                    implementationOfMeasurePerObjectiveSpecific = new ImplementationOfMeasurePerObjectiveDTO()
                    {
                        ActionPlanId = actionPlanId,
                        //ObjectiveIdentifier = "Objektiva" + objectiveStrategic.Identifier + "." + objectiveSpecific.Identifier,
                        ObjectiveIdentifier = objectiveSpecific.Name,
                        NumberOfMeasures = nrOfMeasures,
                        NumberOfImplementedMeasures = count
                    };

                    perObjectiveSpecificDTOs.Add(implementationOfMeasurePerObjectiveSpecific);

                }
            }

            return perObjectiveSpecificDTOs;
        }

        public async Task<ImplementationPieChartDTO> GetOverviewOfImplementationOfMeasures(Guid actionPlanId)
        {
            var objectiveStrategics = await context.ObjectiveStrategics.Where(x => x.ActionPlanId == actionPlanId && x.IsDeleted == false).ToListAsync();
            ImplementationPieChartDTO implementationOfMeasures = new ImplementationPieChartDTO();
            List<Measure> measures = new List<Measure>();
            int implemented = 0;
            int allMeasures = 0;
            byte[] impMeasureDoc = null;
            byte[] notImpMeasureDoc = null;

            foreach (var objectiveStrategic in objectiveStrategics)
            {

                var objectiveSpecifics = await context.ObjectiveSpecifics.Where(x => x.ObjectiveStrategicId == objectiveStrategic.Id && x.IsDeleted == false).ToListAsync();
                foreach (var objectiveSpecific in objectiveSpecifics)
                {
                    measures.AddRange(mapper.Map<List<Measure>>(await measureRepository.GetMeasureDetails(objectiveSpecific.Id)));
                }

            }

            allMeasures = measures.Count;
            implemented = measures.Where(x => x.Status == 1).ToList().Count;

            var impMeasures = measures.Where(x => x.Status == 1).ToList();
            if(impMeasures.Count != 0)
            {
                impMeasureDoc = CreateMeasureDoc(impMeasures);
            }
            
            var notImpMeasures = measures.Where(x => x.Status != 1).ToList();
            if(notImpMeasures.Count != 0)
            {
                notImpMeasureDoc = CreateMeasureDoc(notImpMeasures);
            }


            implementationOfMeasures = new ImplementationPieChartDTO()
            {
                ActionPlanId = actionPlanId,
                Implemented = implemented,
                NotImplemented = allMeasures - implemented,
                ImpDoc = impMeasureDoc,
                NotImpDoc = notImpMeasureDoc,
            };

            return implementationOfMeasures;
        }

        public static byte[] CreateMeasureDoc(List<Measure> measures)  
        {
            using WordDocument document = new WordDocument();

            //Adds a section to the Word document.
            IWSection section = document.AddSection();

            //Sets the page margin
            section.PageSetup.Margins.All = 72;

            //Adds a secondParagraph to the section.
            IWParagraph oaragraph = section.AddParagraph();
            oaragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            if(measures.First().Status == 1){
                oaragraph.ParagraphFormat.AfterSpacing = 20; 
                IWTextRange textRange = oaragraph.AppendText("Aktivitetet e Zbatuara");
                textRange.CharacterFormat.FontSize = 14;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(255, 50, 62, 79);
            }
            else
            {
                oaragraph.ParagraphFormat.AfterSpacing = 20;
                IWTextRange textRange = oaragraph.AppendText("Aktivitetet e Pa Zbatuara");
                textRange.CharacterFormat.FontSize = 14;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(255, 50, 62, 79);
            }

            //Modifies the font size to 10 for default secondParagraph style.
            WParagraphStyle style = document.Styles.FindByName("Normal") as WParagraphStyle;
            style.CharacterFormat.FontSize = 10;

            //Adds a table to the section.
            WTable table = section.AddTable() as WTable;
            table.ResetCells(1, 2);
            table[0, 0].Width = 42f;
            table[0, 0].AddParagraph().AppendText("Nr.");
            table[0, 1].Width = 408f;
            table[0, 1].AddParagraph().AppendText("Aktiviteti");

            WTable tableRow = section.AddTable() as WTable;
            var nrOfRows = measures.Count();
            tableRow.ResetCells(1, 2);
            var rowCount = 0;

            foreach (var measure in measures.OrderBy(x => x.Identifier))
            {
                if (rowCount != 0)
                {
                    tableRow.AddRow();
                }
                tableRow.ApplyHorizontalMerge(rowCount, 1, 1);
                tableRow[rowCount, 0].Width = 42f;
                tableRow[rowCount, 0].AddParagraph().AppendText((rowCount+1).ToString());
                tableRow[rowCount, 1].Width = 408f;
                tableRow[rowCount, 1].AddParagraph().AppendText(measure.Name);
                rowCount++;
            }

            table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent1);
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            return stream.ToArray();
        }

        public static byte[] CreateIndicatorDoc(List<IndicatorSpecific> indicatorsSpecific, List<IndicatorStrategic> indicatorsStrategics)
        {
            using WordDocument document = new WordDocument();


            //-----FIRST TABLE-----
            //Adds a section to the Word document.
            IWSection firstSection = document.AddSection();

            //Sets the page margin
            firstSection.PageSetup.Margins.All = 72;

            //Adds a secondParagraph to the section.
            IWParagraph firstParagraph = firstSection.AddParagraph();
            firstParagraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            if (indicatorsStrategics.First().IndicatorStatusId == 1 || indicatorsStrategics.First().IndicatorStatusId == 3)
            {
                firstParagraph.ParagraphFormat.AfterSpacing = 20;
                IWTextRange textRange = firstParagraph.AppendText("Indikatorët Strategjik Të Zbatuar");
                textRange.CharacterFormat.FontSize = 14;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(255, 50, 62, 79);
            }
            else
            {
                firstParagraph.ParagraphFormat.AfterSpacing = 20;
                IWTextRange textRange = firstParagraph.AppendText("Indikatorët Strategjik Të Pa Zbatuara");
                textRange.CharacterFormat.FontSize = 14;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(255, 50, 62, 79);
            }

            //Modifies the font size to 10 for default secondParagraph style.
            WParagraphStyle firstStyle = document.Styles.FindByName("Normal") as WParagraphStyle;
            firstStyle.CharacterFormat.FontSize = 10;

            //Adds a table to the section.
            WTable firstTable = firstSection.AddTable() as WTable;
            firstTable.ResetCells(1, 2);
            firstTable[0, 0].Width = 42f;
            firstTable[0, 0].AddParagraph().AppendText("Nr.");
            firstTable[0, 1].Width = 408f;
            firstTable[0, 1].AddParagraph().AppendText("Indikatori");

            WTable firstTableRow = firstSection.AddTable() as WTable;
            firstTableRow.ResetCells(1, 2);
            var firstRowCount = 0;

            foreach (var indicator in indicatorsStrategics.OrderBy(x => x.Identifier))
            {
                if (firstRowCount != 0)
                {
                    firstTableRow.AddRow();
                }
                firstTableRow.ApplyHorizontalMerge(firstRowCount, 1, 1);
                firstTableRow[firstRowCount, 0].Width = 42f;
                firstTableRow[firstRowCount, 0].AddParagraph().AppendText((firstRowCount + 1).ToString());
                firstTableRow[firstRowCount, 1].Width = 408f;
                firstTableRow[firstRowCount, 1].AddParagraph().AppendText(indicator.Name);
                firstRowCount++;
            }

            firstTable.ApplyStyle(BuiltinTableStyle.MediumShading1Accent1);


            //-----SECOND TABLE-----
            //Adds a section to the Word document.
            IWSection secondSection = document.AddSection();

            //Sets the page margin
            secondSection.PageSetup.Margins.All = 72;

            //Adds a secondParagraph to the section.
            IWParagraph secondParagraph = secondSection.AddParagraph();
            secondParagraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            if (indicatorsSpecific.First().IndicatorStatusId == 1 || indicatorsSpecific.First().IndicatorStatusId == 3)
            {
                secondParagraph.ParagraphFormat.AfterSpacing = 20;
                IWTextRange textRange = secondParagraph.AppendText("Indikatorët Specifik Të Zbatuar");
                textRange.CharacterFormat.FontSize = 14;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(255, 50, 62, 79);
            }
            else
            {
                secondParagraph.ParagraphFormat.AfterSpacing = 20;
                IWTextRange textRange = secondParagraph.AppendText("Indikatorët Specifik Të Pa Zbatuara");
                textRange.CharacterFormat.FontSize = 14;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(255, 50, 62, 79);
            }

            //Modifies the font size to 10 for default secondParagraph style.
            WParagraphStyle style = document.Styles.FindByName("Normal") as WParagraphStyle;
            style.CharacterFormat.FontSize = 10;

            //Adds a table to the section. 
            WTable secondTable = secondSection.AddTable() as WTable;
            secondTable.ResetCells(1, 2);
            secondTable[0, 0].Width = 42f;
            secondTable[0, 0].AddParagraph().AppendText("Nr.");
            secondTable[0, 1].Width = 408f;
            secondTable[0, 1].AddParagraph().AppendText("Indikatori");

            WTable secondTableRow = secondSection.AddTable() as WTable;
            var nrOfRows = indicatorsSpecific.Count();
            secondTableRow.ResetCells(1, 2);
            var secondRowCount = 0;

            foreach (var indicator in indicatorsSpecific.OrderBy(x => x.Identifier))
            {
                if (secondRowCount != 0)
                {
                    secondTableRow.AddRow();
                }
                secondTableRow.ApplyHorizontalMerge(secondRowCount, 1, 1);
                secondTableRow[secondRowCount, 0].Width = 42f;
                secondTableRow[secondRowCount, 0].AddParagraph().AppendText((secondRowCount + 1).ToString());
                secondTableRow[secondRowCount, 1].Width = 408f;
                secondTableRow[secondRowCount, 1].AddParagraph().AppendText(indicator.Name);
                secondRowCount++;
            }

            secondTable.ApplyStyle(BuiltinTableStyle.MediumShading1Accent1);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            return stream.ToArray();
        }



    }
}
