import { ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, } from '@angular/forms';
import Chart from 'chart.js';
import { isUndefined } from 'util';
import { OverviewService } from '../../../@core/services/overview.service';
import { SettingsService } from '../../../@core/services/settings.service';
import { ActionPlanDetailsViewModel } from '../../../@core/viewModels/ActionPlanDetailsViewModel';
import { DocumentsDTOViewModel } from '../../../@core/viewModels/DocumentsDTOViewModel';
import { ImplementationOfMeasurePerInstitutionViewModel } from '../../../@core/viewModels/ImplementationOfMeasurePerInstitutionViewModel';
import { ImplementationOfMeasurePerObjectiveViewModel } from '../../../@core/viewModels/ImplementationOfMeasurePerObjectiveViewModel';
import { ImplementationPieChartViewModel } from '../../../@core/viewModels/ImplementationPieChartViewModel';
import { StatisticOfPlanViewModel } from '../../../@core/viewModels/StatisticOfPlanViewModel';
import * as Highcharts from 'highcharts';

declare var require: any;

import highcharts3D from 'highcharts/highcharts-3d';
highcharts3D(Highcharts);

const Exporting = require('highcharts/modules/exporting');
Exporting(Highcharts);

import cylinder from 'highcharts/modules/cylinder';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { NewsService } from '../../../@core/services/news.service';
import { ReportImplemenationService } from '../../../@core/services/report-implement.service';
import { INewsPage } from '../../../@core/interfaces/INewsPage';
import { IFileManagement } from '../../../@core/interfaces/IFileManagement';
import { IReportImplementation } from '../../../@core/interfaces/IReportImplementation';
import { map } from 'rxjs/operators';
import { SendEmailViewModel } from '../../../@core/viewModels/SendEmailViewModel';
import { ReCaptcha2Component } from 'ngx-captcha';
import { IPublicCodes } from '../../../@core/interfaces/IPublicCodes';
import { FileManagementService } from '../../../@core/services/file-management.service';
import { DataService } from '../../../@core/services/data.service';
cylinder(Highcharts);


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  implementationMeasurePerInstitution: ImplementationOfMeasurePerInstitutionViewModel[] = new Array<ImplementationOfMeasurePerInstitutionViewModel>();
  implementationMeasurePerObjectiveStra: ImplementationOfMeasurePerObjectiveViewModel[] = new Array<ImplementationOfMeasurePerObjectiveViewModel>();
  implementationMeasurePerObjectiveSpe: ImplementationOfMeasurePerObjectiveViewModel[] = new Array<ImplementationOfMeasurePerObjectiveViewModel>();
  implementationIndicators: ImplementationPieChartViewModel = new ImplementationPieChartViewModel();
  implementationMeasures: ImplementationPieChartViewModel = new ImplementationPieChartViewModel();
  actionPlans: ActionPlanDetailsViewModel[] = new Array<ActionPlanDetailsViewModel>();
  selectedActionPlan: any;
  selectedActionPlanId: any;
  actionPlanName: any;
  fileName: any;
  fileRef: any;
  indicatorFileRef: string;
  indicatorFileName: string;
  statisticOfPlan: StatisticOfPlanViewModel = new StatisticOfPlanViewModel();
  GVRAPConclusions: DocumentsDTOViewModel[] = new Array<DocumentsDTOViewModel>();
  KMRAPConclusions: DocumentsDTOViewModel[] = new Array<DocumentsDTOViewModel>();
  RAPStrategies: DocumentsDTOViewModel[] = new Array<DocumentsDTOViewModel>();
  ImplementationReports: DocumentsDTOViewModel[] = new Array<DocumentsDTOViewModel>();
  GovernmentProgram: DocumentsDTOViewModel[] = new Array<DocumentsDTOViewModel>();


  //highcharts options
  measuresOptions: any;
  indicatorsOptions: any;
  objSpeOptions: any;
  objStraOptions: any;
  institutionOptions: any;


  institutionLabels: any[] = [];
  institutionNotImpDatas: any[] = [];
  institutionImpDatas: any[] = [];

  objectiveStraLabels: any[] = [];
  objectiveStraNrDatas: any[] = [];
  objectiveStraImpDatas: any[] = [];

  objectiveSpeLabels: any[] = [];
  objectiveSpeNrDatas: any[] = [];
  objectiveSpeImpDatas: any[] = [];

  news: INewsPage = null;
  codes: IPublicCodes[] = null;
  isDataAvaible: boolean = false;
  isActive: boolean = false;
  conclusionFiles: IFileManagement[];
  goalsFiles: IFileManagement[];
  minutesFiles: IFileManagement[];
  strategiesFiles: IFileManagement[];
  comunicationFiles: IFileManagement[];

  report: IReportImplementation = null;

  //Contact Form
  createContact: FormGroup;
  public sendEmailViewModel: SendEmailViewModel = new SendEmailViewModel();
  loading = false;
  siteKey: string = "6LcGHcIdAAAAABZsYQ0xj7qumO96Its3rbVL_g33";
  @ViewChild('captchaElem') captchaElem: ReCaptcha2Component;
  isError: boolean = null;
  message: string = null;

  constructor(private overviewService: OverviewService,
    private formBuilder: FormBuilder,
    private settingsService: SettingsService,
    private fileMenager: FileManagementService,
    private translate: TranslateService,
    private newsService: NewsService,
    private router: Router,
    private reportImplemenationService: ReportImplemenationService,
    private elementRef: ElementRef,
    private cdr: ChangeDetectorRef,
    private data: DataService) {
    this.setText();
    translate.setDefaultLang('al');
    this.createContactForm();
    this.data.currentMessage.subscribe(message => this.message = message);
  }

  ngOnDestroy(): void {
    this.elementRef.nativeElement.remove();
  }

  ngOnInit(): void {
    this.getActionPlans();
    this.getGVRAPConclusions();
    this.getKMRAPConclusions();
    this.getRAPStrategies();
    this.getRAPImplementationReports();
    this.getGovernmentProgram();
    this.getNews();
    this.getFilesByCategory("ED7EC76F-D03B-4854-B1AF-9995CBD24BDA", "conclusionFiles");
    this.getFilesByCategory("0EE46F80-EEB5-4E2B-B415-A04B98322C1E", "goalsFiles");
    this.getFilesByCategory("799E544C-3684-4AFA-ACB3-4693A5BBCECC", "minutesFiles");
    this.getFilesByCategory("F8786327-FBEE-4B35-8275-27382634AF8D", "strategiesFiles");
    this.getFilesByCategory("88BA81AB-BB51-40B7-BA2A-4044AC6A26B8", "comunicationFiles");
  }

  useLanguage(language: string): void {
    this.settingsService.getPublicCodes(language).subscribe(x => { this.codes = x; this.data.changeMessage(JSON.stringify(x)); });
    localStorage.setItem('codes', JSON.stringify(this.codes));
  }

  setText() {
    this.settingsService.getPublicCodes('al').subscribe(x => { this.codes = x; localStorage.setItem('codes', JSON.stringify(x)); this.data.changeMessage(JSON.stringify(x));; this.isDataAvaible = true });
  }

  getTextId(id): string {
    return this.codes.find(x => x.id == id).name;
  }

  getActionPlans() {
    this.overviewService.getActionPlans().subscribe(response => {
      this.actionPlans = response;
      this.selectedActionPlan = this.actionPlans[0];
      this.selectedActionPlanId = this.selectedActionPlan.id;
      this.actionPlanName = this.actionPlans[0].name;
      this.fileRef = this.actionPlans[0].fileRef;
      this.fileName = this.actionPlans[0].fileName;
      this.indicatorFileRef = this.actionPlans[0].indicatorFileRef;
      this.indicatorFileName = this.actionPlans[0].indicatorFileName;
      this.getOverviewOfImplementationOfMeasurePerObjectiveStrategic(this.selectedActionPlanId);
      this.getStatisticOfPlans(this.selectedActionPlanId);
      this.getGovernmentProgram;
      this.isPDF(this.fileName);
      this.isPDF(this.indicatorFileName);
    });
  }

  getFilesByCategory(categoryId, list) {
    this.fileMenager.getFilesManagement(1, 4, categoryId).subscribe(response => { this[list] = response.data; console.log(response.data, list) });
  }

  //get GVRAP docs
  getGVRAPConclusions() {
    this.settingsService.getGVRAPConclusions().subscribe(response => {
      this.GVRAPConclusions = response;
      for (var i = 0; i < this.GVRAPConclusions.length; i++) {
        if (this.GVRAPConclusions[i].fileName.includes(".pdf")) {
          this.GVRAPConclusions[i].isPDF = true;
        } else {
          this.GVRAPConclusions[i].isPDF = false;
        }
      }
    })
  }

  //get KMRAP docs
  getKMRAPConclusions() {
    this.settingsService.getKMRAPConclusions().subscribe(response => {
      this.KMRAPConclusions = response;
      for (var i = 0; i < this.KMRAPConclusions.length; i++) {
        if (this.KMRAPConclusions[i].fileName.includes(".pdf")) {
          this.KMRAPConclusions[i].isPDF = true;
        } else {
          this.KMRAPConclusions[i].isPDF = false;
        }
      }
    })
  }

  //get rap strategies docs
  getRAPStrategies() {
    this.settingsService.getRAPStrategies().subscribe(response => {
      this.RAPStrategies = response;
      for (var i = 0; i < this.RAPStrategies.length; i++) {
        if (this.RAPStrategies[i].fileName.includes(".pdf")) {
          this.RAPStrategies[i].isPDF = true;
        } else {
          this.RAPStrategies[i].isPDF = false;
        }
      }
    })
  }

  //get gov program doc
  getGovernmentProgram() {
    this.settingsService.getGovernmentProgram().subscribe(response => {
      this.GovernmentProgram = response;
      for (var i = 0; i < this.GovernmentProgram.length; i++) {
        if (this.GovernmentProgram[i].fileName.includes(".pdf")) {
          this.GovernmentProgram[i].isPDF = true;
        } else {
          this.GovernmentProgram[i].isPDF = false;
        }
      }
    })
  }

  //get RAP Implementation Reports docs
  getRAPImplementationReports() {
    this.settingsService.getRAPImplementationReports().subscribe(response => {
      this.ImplementationReports = response;
      for (var i = 0; i < this.ImplementationReports.length; i++) {
        if (this.ImplementationReports[i].fileName.includes(".pdf")) {
          this.ImplementationReports[i].isPDF = true;
        } else {
          this.ImplementationReports[i].isPDF = false;
        }
      }
    })
  }

  isPdfFile: boolean = false;

  isPDF(value) {
    if (value != null) {
      if (value.includes(".pdf")) {
        this.isPdfFile = true;
      } else {
        this.isPdfFile = false;
      }
    }
  }

  getStatisticOfPlans(actionPlanId) {
    this.overviewService.getStatisticOfPlans(actionPlanId).subscribe(response => {
      this.statisticOfPlan = response;
    });
  }



  actionPlanSelection(event) {
    this.selectedActionPlan = event;
    this.selectedActionPlanId = this.selectedActionPlan.id;
    this.actionPlanName = event.name;
    this.fileName = event.fileName;
    this.fileRef = event.fileRef;
    this.indicatorFileName = event.indicatorFileName;
    this.indicatorFileRef = event.indicatorFileRef;
    this.getOverviewOfImplementationMeasurePerInstitution(this.selectedActionPlanId);
    this.getOverviewOfImplementationOfMeasurePerObjectiveStrategic(this.selectedActionPlanId);
    this.getOverviewOfImplementationOfMeasurePerObjectiveSpecific(this.selectedActionPlanId);
    this.getOverviewOfImplementationOfIndicators(this.selectedActionPlanId);
    this.getOverviewOfImplementationOfMeasures(this.selectedActionPlanId);
    this.getStatisticOfPlans(this.selectedActionPlanId);
    this.isPDF(this.fileName);
    this.isPDF(this.indicatorFileName);
  }

  getOverviewOfImplementationMeasurePerInstitution(actionPlanId) {
    this.institutionLabels = [];
    this.institutionNotImpDatas = [];
    this.institutionImpDatas = [];

    this.overviewService.getOverviewOfImplementationMeasurePerInstitution(actionPlanId).subscribe(response => {
      this.implementationMeasurePerInstitution = response;
      for (var imp of this.implementationMeasurePerInstitution) {
        this.institutionLabels.push(imp.institution.name);
        this.institutionNotImpDatas.push(imp.numberOfMeasures);
        this.institutionImpDatas.push(imp.numberOfImplementedMeasures);
      }
      this.createInstitutionsChart();
    })
  }

  getOverviewOfImplementationOfMeasurePerObjectiveStrategic(actionPlanId) {
    this.objectiveStraLabels = [];
    this.objectiveStraNrDatas = [];
    this.objectiveStraImpDatas = [];

    this.overviewService.getOverviewOfImplementationOfMeasurePerObjectiveStrategic(actionPlanId).subscribe(response => {
      this.implementationMeasurePerObjectiveStra = response;
      for (var imp of this.implementationMeasurePerObjectiveStra) {
        this.objectiveStraLabels.push(imp.objectiveIdentifier);
        this.objectiveStraNrDatas.push(imp.numberOfMeasures);
        this.objectiveStraImpDatas.push(imp.numberOfImplementedMeasures);
      }
      this.createObjectiveStrategicChart();
    })
  }

  getOverviewOfImplementationOfMeasurePerObjectiveSpecific(actionPlanId) {
    this.objectiveSpeLabels = [];
    this.objectiveSpeNrDatas = [];
    this.objectiveSpeImpDatas = [];

    this.overviewService.getOverviewOfImplementationOfMeasurePerObjectiveSpecific(actionPlanId).subscribe(response => {
      this.implementationMeasurePerObjectiveSpe = response;
      for (var imp of this.implementationMeasurePerObjectiveSpe) {
        this.objectiveSpeLabels.push(imp.objectiveIdentifier);
        this.objectiveSpeNrDatas.push(imp.numberOfMeasures);
        this.objectiveSpeImpDatas.push(imp.numberOfImplementedMeasures);
      }
      this.createObjectiveSpecificsChart();
    })
  }


  impIndicatorDocs: any;
  notImpIndicatorDocs: any;

  getOverviewOfImplementationOfIndicators(actionPlanId) {
    this.overviewService.getOverviewOfImplementationOfIndicators(actionPlanId).subscribe(response => {
      this.implementationIndicators = response;
      this.impIndicatorDocs = this.base64ToArrayBuffer(this.implementationIndicators.impDoc);
      this.notImpIndicatorDocs = this.base64ToArrayBuffer(this.implementationIndicators.notImpDoc);
      this.createIndicatorChart();
    })
  }

  impMeasureDocs: any;
  notImpMeasureDocs: any;

  getOverviewOfImplementationOfMeasures(actionPlanId) {
    this.overviewService.getOverviewOfImplementationOfMeasures(actionPlanId).subscribe(response => {
      this.implementationMeasures = response;
      this.impMeasureDocs = this.base64ToArrayBuffer(this.implementationMeasures.impDoc);
      this.notImpMeasureDocs = this.base64ToArrayBuffer(this.implementationMeasures.notImpDoc);
      this.createMeasureChart();
    })
  }

  //download docs
  downloadImpIndicatorDocs() {
    this.downLoadFile(this.impIndicatorDocs, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Indikatorët e zbatuar");
  }

  downloadNotImpIndicatorDocs() {
    this.downLoadFile(this.notImpIndicatorDocs, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Indikatorët e pa zbatuar");
  }

  downloadImpMeasureDocs() {
    this.downLoadFile(this.impMeasureDocs, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Aktivitetet e zbatuara");
  }

  downloadNotImpMeasureDocs() {
    this.downLoadFile(this.notImpMeasureDocs, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Aktivitetet e pa zbatuara");
  }

  downloadDoc(path: string, fileName: string) {
    this.settingsService.downloadDoc(path).subscribe(response => {
      this.downLoadFile(response, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
    });
  }

  downloadStaticDoc(path: string, fileName: string) {
    this.settingsService.downloadStaticDoc(path).subscribe(response => {
      this.downLoadFile(response, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
    });
  }

  downLoadFile(data: any, type: string, fileName: string) {
    const a = document.createElement('a');
    document.body.appendChild(a);
    const blob = new Blob([data], { type: type });
    const url = window.URL.createObjectURL(blob);
    a.href = url;
    a.download = fileName;
    a.click();
    window.URL.revokeObjectURL(url);
  }

  base64ToArrayBuffer(base64) {
    var binaryString = window.atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
      var ascii = binaryString.charCodeAt(i);
      bytes[i] = ascii;
    }
    return bytes;
  }

  createInstitutionsChart() {
    //INSTITUTIONS
    this.institutionOptions = {
      chart: {
        type: 'column',
        backgroundColor: 'transparent',
        options3d: {
          enabled: true,
          alpha: 7,
          beta: 7,
          viewDistance: 25,
          depth: 150
        }
      },

      title: {
        text: ''
      },

      xAxis: {
        categories: this.institutionLabels,
        labels: {
          skew3d: true,
          style: {
            fontSize: '20px'
          }
        }
      },

      yAxis: {
        allowDecimals: false,
        min: 0,
        title: {
          text: 'Numri i aktiviteteve',
          skew3d: true,
          style: {
            fontSize: '20px'
          },
        }
      },

      tooltip: {
        headerFormat: '<b>{point.key}</b><br>',
        pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
      },

      plotOptions: {
        series: {
          depth: 100,
        },
        column: {
          stacking: 'normal',
          depth: 40
        }
      },

      series: [
        {
          name: 'Pa Zbatuar',
          data: this.institutionNotImpDatas,
          stack: 'male',
          color: '#BEE1E0',
        }, {
          name: 'Zbatuar',
          data: this.institutionImpDatas,
          stack: 'male',
          color: '#D3BAD3',
        }],
      exporting: {
        enabled: false
      },
      credits: {
        enabled: false
      },
    };

    Highcharts.chart('chart-bar-double-datasets-example', this.institutionOptions);
  }

  createObjectiveStrategicChart() {
    //Objective Strategics

    this.objStraOptions = {
      chart: {
        type: 'cylinder',
        backgroundColor: 'transparent',
        options3d: {
          enabled: true,
          alpha: 7,
          beta: 7,
          viewDistance: 25,
          depth: 150
        }
      },

      title: {
        text: null
      },

      xAxis: {
        categories: this.objectiveStraLabels,
        labels: {
          skew3d: true,
          style: {
            fontSize: '20px'
          },
          rotation: -60
        }
      },

      yAxis: {
        allowDecimals: false,
        min: 0,
        title: {
          text: 'Numri i aktiviteteve',
          skew3d: true,
          style: {
            fontSize: '20px'
          },
        }
      },

      tooltip: {
        headerFormat: '<b>{point.key}</b><br>',
        pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y}'
      },

      plotOptions: {
        series: {
          depth: 100,
        },
        column: {
          stacking: 'normal',
          depth: 40
        }
      },

      series: [{
        name: 'Gjithësej',
        data: this.objectiveStraNrDatas,
        stack: 'male',
        color: '#A9D1F7',
      }, {
        name: 'Zbatuar',
        data: this.objectiveStraImpDatas,
        stack: 'male',
        color: '#FFB1B0',
      }],
      exporting: {
        enabled: false
      },
      credits: {
        enabled: false
      },
    };

    Highcharts.chart('chart-bar', this.objStraOptions);
  }

  createObjectiveSpecificsChart() {
    //Objective Specifics

    this.objSpeOptions = {
      chart: {
        type: 'column',
        backgroundColor: 'transparent',
        options3d: {
          enabled: true,
          alpha: 7,
          beta: 7,
          viewDistance: 25,
          depth: 150
        }
      },

      title: {
        text: ''
      },

      xAxis: {
        categories: this.objectiveSpeLabels,
        labels: {
          skew3d: true,
          style: {
            fontSize: '20px'
          },
          rotation: -60
        }
      },

      yAxis: {
        allowDecimals: false,
        min: 0,
        title: {
          text: 'Numri i aktiviteteve',
          skew3d: true,
          style: {
            fontSize: '20px'
          }
        }
      },

      tooltip: {
        headerFormat: '<b>{point.key}</b><br>',
        pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y}'
      },

      series: [{
        name: 'Gjithesej',
        data: this.objectiveSpeNrDatas,
        stack: 'male',
        color: '#92a8d1',
      }, {
        name: 'Zbatuar',
        data: this.objectiveSpeImpDatas,
        stack: 'male',
        color: '#f7cac9',
      }],
      exporting: {
        enabled: false
      },
      credits: {
        enabled: false
      },
    };

    Highcharts.chart('bar-chart-horizontal', this.objSpeOptions);
  }

  createIndicatorChart() {
    //INDICATORS

    this.indicatorsOptions = {
      chart: {
        type: 'pie',
        backgroundColor: 'transparent',
        options3d: {
          enabled: true,
          alpha: 45
        }
      },
      title: {
        text: ''
      },
      accessibility: {
        point: {
          valueSuffix: '%'
        }
      },
      tooltip: {
        pointFormat: '{point.y} {series.name}'
      },
      plotOptions: {
        pie: {
          innerSize: 100,
          depth: 45,
          allowPointSelect: true,
          cursor: 'pointer',
          dataLabels: {
            enabled: true,
            format: '{point.name}'
          }
        }
      },
      series: [{
        name: 'Indikatorë',
        data: [
          {
            name: 'Zbatuar',
            y: this.implementationIndicators.implemented,
            sliced: true,
            selected: true,
            color: '#F7D8BA',
          },
          {
            name: 'Pa Zbatuar',
            y: this.implementationIndicators.notImplemented,
            color: '#ACDDDE'
          }
        ]
      }],
      exporting: {
        enabled: false
      },
      credits: {
        enabled: false
      },
    };
    Highcharts.chart('chart-doughnut', this.indicatorsOptions);
  }

  createMeasureChart() {
    //Measures
    this.measuresOptions = {
      chart: {
        type: 'pie',
        backgroundColor: 'transparent',
        options3d: {
          enabled: true,
          alpha: 45,
          beta: 0
        }
      },
      title: {
        text: null
      },
      accessibility: {
        point: {
          valueSuffix: '%'
        }
      },
      tooltip: {
        pointFormat: '{point.y} {series.name}'
      },
      plotOptions: {
        pie: {
          allowPointSelect: true,
          cursor: 'pointer',
          depth: 35,
          dataLabels: {
            enabled: true,
            format: '{point.name}'
          }
        }
      },
      series: [{
        type: 'pie',
        name: 'Aktivitete',
        data: [
          {
            name: 'Pa Zbatuar',
            y: this.implementationMeasures.notImplemented,
            color: '#ED8975'
          },
          {
            name: 'Zbatuar',
            y: this.implementationMeasures.implemented,
            sliced: true,
            selected: true,
            color: '#B2E7E8'
          },
        ]
      }],
      exporting: {
        enabled: false
      },
      credits: {
        enabled: false
      },
    };
    Highcharts.chart('chart-pie', this.measuresOptions);
  }

  getNews() {
    this.newsService.getNewsPaged(1, 3).pipe(
      map((newsData: INewsPage) => {
        this.news = newsData;
        for (var i = 0; i < this.news.data.length; i++) {
          this.news.data[i].imageUrl = this.news.data[i].imageUrl.replace(/\\/g, "/");
        }
      })
    ).subscribe();
  }

  getReports() {
    this.reportImplemenationService.getReportPaged(1, 3).pipe(
      map((reportData: IReportImplementation) => {
        this.report = reportData;
        for (var i = 0; i < this.report.data.length; i++) {
          this.report.data[i].imageUrl = this.report.data[i].imageUrl.replace(/\\/g, "/");
        }
        this.report.data.sort(() => 0.5 - Math.random());
      })
    ).subscribe();
  }

  getInnerText(el) {
    return el.innerText;
  }


  createContactForm() {
    this.createContact = this.formBuilder.group({
      name: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      message: [null, [Validators.required]],
      recaptcha: ['', Validators.required]

    })
  }


  onSubmitContact() {
    this.createContact["submitted"] = true;
    if (this.createContact.valid && this.loading != true) {
      this.loading = true;
      var sendEmailViewModel = this.createContact.value as SendEmailViewModel;
      this.settingsService.sendEmail(sendEmailViewModel).subscribe(
        (response: any) => {
          this.createContact.reset();
          this.captchaElem.reloadCaptcha();
          this.isError = false;
          this.loading = false;
        },
        (error) => {
          this.captchaElem.resetCaptcha();
          this.loading = false;
          this.isError = true;
        },
        () => {
          this.loading = false;
        });
    }
  }

}
