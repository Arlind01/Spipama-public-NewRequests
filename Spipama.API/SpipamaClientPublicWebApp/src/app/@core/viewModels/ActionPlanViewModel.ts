import { DatePipe, DecimalPipe } from "@angular/common";

export class ActionPlanViewModel {
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
  createdBy: string;
  createdOn: DatePipe;
  updatedBy: string;
  updatedOn: DatePipe;
  isDeleted: boolean;


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
  ) {
    this.id = id;
    this.name = name;
    this.strategyName = strategyName;
    this.startYear = startYear;
    this.endYear = endYear;
    this.activeYear = activeYear;
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
  }
}
