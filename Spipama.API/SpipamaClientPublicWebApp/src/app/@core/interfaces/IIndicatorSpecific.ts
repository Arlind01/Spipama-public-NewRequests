import { IIndicatorDetails } from "./IIndicatorDetails";

export interface IIndicatorSpecific {
  id: string;
  objectiveSpecificId: string;
  identifier: number;
  name: string;
  base: string;
  inputType?: number;
  indicatorStatusId: number;
  isDeleted?: boolean;
  indicatorDetails: IIndicatorDetails[];
  responsibleInstitutionId: string;
  result: string;
}
