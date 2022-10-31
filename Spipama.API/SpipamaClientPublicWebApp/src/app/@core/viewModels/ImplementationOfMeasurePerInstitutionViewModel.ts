import { InstitutionViewModel } from "./InstitutionViewModel";

export class ImplementationOfMeasurePerInstitutionViewModel {
  actionPlanId: string;
  institution: InstitutionViewModel;
  numberOfMeasures: number;
  numberOfImplementedMeasures: number;

  constructor(
    actionPlanId: string = null,
    institution: InstitutionViewModel = null,
    numberOfMeasures: number = null,
    numberOfImplementedMeasures: number = null
  ) {
    this.actionPlanId = actionPlanId;
    this.institution = institution;
    this.numberOfMeasures = numberOfMeasures;
    this.numberOfImplementedMeasures = numberOfImplementedMeasures;
  }

}
