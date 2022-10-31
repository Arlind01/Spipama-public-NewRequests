import { DecimalPipe } from "@angular/common";
import { IInstitution } from "./IInstitution";
import { IMeasureDetails } from "./IMeasureDetails";

export interface IMeasure {
  id: string;
  identifier: number;
  objectiveSpecificId: string;
  name: string;
  periodFrom: Date;
  periodTo: Date;
  totalBudget: DecimalPipe;
  totalBudgetSpent?: DecimalPipe;
  product: string;
  institution?: string;
  reference: string;
  status: number;
  isDeleted?: boolean;
  measureDetails: IMeasureDetails[];
  responsibleInstitutionId: string;
  responsibleInstitution: IInstitution[];
}
