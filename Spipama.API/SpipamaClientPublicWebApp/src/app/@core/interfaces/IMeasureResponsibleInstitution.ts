import { IInstitution } from "./IInstitution";

export interface IMeasureResponsibleInstitution {
  id: string;
  measureId: string;
  institutionId: string;
  institution: IInstitution;
}
