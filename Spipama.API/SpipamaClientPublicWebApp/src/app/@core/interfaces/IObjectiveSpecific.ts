import { DecimalPipe } from "@angular/common";

export interface IObjectiveSpecific {
  id: string;
  identifier: number;
  actionPlanId: string;
  name: string;
  budgetTotal?: number;
  budgetCapital?: number;
  budgetCost?: number;
  isDeleted?: boolean;
  gap?: DecimalPipe;
}
