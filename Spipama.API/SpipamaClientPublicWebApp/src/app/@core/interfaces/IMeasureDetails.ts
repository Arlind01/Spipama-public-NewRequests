import { DecimalPipe } from "@angular/common";
import { IStrategySourceOfFounding } from "./IStrategySourceOfFounding";

export interface IMeasureDetails{
  id?: string;
  measureId?: string;
  year?: number;
  budget?: DecimalPipe;
  budgetSpent?: DecimalPipe;
  strategySourceOfFundingId?: string;
  strategySourceOfFunding: IStrategySourceOfFounding;
  isDeleted?: boolean;
}
