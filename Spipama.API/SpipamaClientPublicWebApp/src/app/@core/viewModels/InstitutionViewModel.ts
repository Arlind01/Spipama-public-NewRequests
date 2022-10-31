import { DatePipe, DecimalPipe } from "@angular/common";

export class InstitutionViewModel
{
  id: string;
  name: string;
  createdBy: string;
  createdOn: DatePipe;
  updatedBy: string;
  updatedOn: DatePipe;
  isDeleted: boolean;

  constructor
    (
    id: string = null,
    name: string = null,
    createdBy: string = null,
    createdOn: DatePipe = null,
    updatedBy: string = null,
    updatedOn: DatePipe = null,
    isDeleted: boolean = null
  ) {
    this.id = id;
    this.name = name;
    this.createdBy = createdBy;
    this.createdOn = createdOn;
    this.updatedBy = updatedBy;
    this.updatedOn = updatedOn;
    this.isDeleted = isDeleted;
  }
}
