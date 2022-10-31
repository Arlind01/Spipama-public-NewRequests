export class ImplementationOfMeasurePerObjectiveViewModel {
  actionPlanId: string;
  objectiveIdentifier: string;
  numberOfMeasures: number;
  numberOfImplementedMeasures: number;

  constructor(
    actionPlanId: string = null,
    objectiveIdentifier: string = null,
    numberOfMeasures: number = null,
    numberOfImplementedMeasures: number = null
  ) {
    this.actionPlanId = actionPlanId;
    this.objectiveIdentifier = objectiveIdentifier;
    this.numberOfMeasures = numberOfMeasures;
    this.numberOfImplementedMeasures = numberOfImplementedMeasures;
  }

}
