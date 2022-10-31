import { DatePipe, DecimalPipe } from "@angular/common";
import { IIndicatorSpecific } from "../interfaces/IIndicatorSpecific";
import { IIndicatorStrategic } from "../interfaces/IIndicatorStrategic";
import { IMeasure } from "../interfaces/IMeasure";
import { IMeasureResponsibleInstitution } from "../interfaces/IMeasureResponsibleInstitution";
import { IObjectiveSpecific } from "../interfaces/IObjectiveSpecific";
import { IObjectiveStrategic } from "../interfaces/IObjectiveStrategic";

export class ActionPlanDetailsViewModel {
  id: string;
  name: string;
  strategyName: string;
  startYear: number;
  endYear: number;
  activeYear: number;
  status: number;
  budgetTotal: DecimalPipe;
  budgetCapital: DecimalPipe;
  budgetCost: DecimalPipe;
  fileRef: string;
  fileName: string;
  indicatorFileRef: string;
  indicatorFileName: string;
  createdBy: string;
  createdOn: DatePipe;
  updatedBy: string;
  updatedOn: DatePipe 
  isDeleted: boolean;
  objectiveStrategics: IObjectiveStrategic[];
  indicatorStrategics: IIndicatorStrategic[];
  objectiveSpecifics: IObjectiveSpecific[];
  indicatorSpecifics: IIndicatorSpecific[];
  measures: IMeasure[];
  measureResponsibleInstitutions: IMeasureResponsibleInstitution[];
  gap?: DecimalPipe;


  constructor(
    id: string = null,
    name: string = null,
    strategyName: string = null,
    startYear: number = null,
    endYear: number = null,
    activeYear: number = null,
    status: number = null, 
    budgetTotal: DecimalPipe = null,
    budgetCapital: DecimalPipe = null,
    budgetCost: DecimalPipe = null,
    fileRef: string = null,
    fileName: string = null,
    createdBy: string = null,
    createdOn: DatePipe = null,
    updatedBy: string = null,
    updatedOn: DatePipe = null,
    isDeleted: boolean = null,
    objectiveStrategics: IObjectiveStrategic[] = null,
    indicatorStrategics: IIndicatorStrategic[] = null,
    objectiveSpecifics: IObjectiveSpecific[] = null,
    indicatorSpecifics: IIndicatorSpecific[] = null,
    measures: IMeasure[] = null,
    gap: DecimalPipe = null,
  ) {
    this.id = id;
    this.name = name;
    this.strategyName = strategyName;
    this.startYear = startYear;
    this.activeYear = activeYear;
    this.endYear = endYear;
    this.status = status;
    this.budgetTotal = budgetTotal;
    this.budgetCapital = budgetCapital;
    this.budgetCost = budgetCost;
    this.fileRef = fileRef;
    this.fileName = fileName;
    this.createdBy = createdBy;
    this.createdOn = createdOn;
    this.updatedBy = updatedBy;
    this.updatedOn = updatedOn;
    this.isDeleted = isDeleted;
    this.objectiveStrategics = objectiveStrategics;
    this.indicatorStrategics = indicatorStrategics;
    this.objectiveSpecifics = objectiveSpecifics;
    this.indicatorSpecifics = indicatorSpecifics;
    this.measures = measures;
    this.gap = gap;
  }
}
