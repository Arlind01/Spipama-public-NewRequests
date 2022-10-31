export class StatisticOfPlanViewModel {
  allActionPlans: number;
  activeActionPlans: number;
  allMeasures: number;
  implementedMeasures: number;

  constructor(
    allActionPlans: number = null,
    activeActionPlans: number = null,
    allMeasures: number = null,
    implementedMeasures: number = null
  ) {
    this.allActionPlans = allActionPlans;
    this.activeActionPlans = activeActionPlans;
    this.allMeasures = allMeasures;
    this.implementedMeasures = implementedMeasures;
  }

}
