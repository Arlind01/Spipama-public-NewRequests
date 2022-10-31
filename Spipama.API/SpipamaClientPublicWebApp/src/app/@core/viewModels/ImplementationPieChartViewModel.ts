export class ImplementationPieChartViewModel {
  actionPlanId: string;
  implemented: number;
  notImplemented: number;
  impDoc: any;
  notImpDoc: any;

  constructor(
    actionPlanId: string = null,
    implemented: number = null,
    notImplemented: number = null,
    impDoc: any = null,
    notImpDoc: any = null
  ) {
    this.actionPlanId = actionPlanId;
    this.implemented = implemented;
    this.notImplemented = notImplemented;
    this.impDoc = impDoc;
    this.notImpDoc = notImpDoc;
  }

}
