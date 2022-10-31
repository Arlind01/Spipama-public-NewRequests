import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ActionPlanDetailsViewModel } from '../viewModels/ActionPlanDetailsViewModel';
import { ImplementationOfMeasurePerInstitutionViewModel } from '../viewModels/ImplementationOfMeasurePerInstitutionViewModel';
import { ImplementationOfMeasurePerObjectiveViewModel } from '../viewModels/ImplementationOfMeasurePerObjectiveViewModel';
import { ImplementationPieChartViewModel } from '../viewModels/ImplementationPieChartViewModel';
import { StatisticOfPlanViewModel } from '../viewModels/StatisticOfPlanViewModel';

@Injectable({
  providedIn: 'root'
})
export class OverviewService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  baseUrl = environment.apiEndpoint + 'api/Overview/';

  getActionPlans(): Observable<ActionPlanDetailsViewModel[]> {
    return this.httpClient.get<ActionPlanDetailsViewModel[]>(this.baseUrl + "getActionPlans");
  }

  getOverviewOfImplementationMeasurePerInstitution(actionPlanId: string): Observable<ImplementationOfMeasurePerInstitutionViewModel[]> {
    return this.httpClient.get<ImplementationOfMeasurePerInstitutionViewModel[]>(this.baseUrl + "getOverviewOfImplementationMeasurePerInstitution/" + actionPlanId, {});
  }

  getOverviewOfImplementationOfMeasurePerObjectiveStrategic(actionPlanId: string): Observable<ImplementationOfMeasurePerObjectiveViewModel[]> {
    return this.httpClient.get<ImplementationOfMeasurePerObjectiveViewModel[]>(this.baseUrl + "getOverviewOfImplementationOfMeasurePerObjectiveStrategic/" + actionPlanId, {});
  }

  getOverviewOfImplementationOfIndicators(actionPlanId: string): Observable<ImplementationPieChartViewModel> {
    return this.httpClient.get<ImplementationPieChartViewModel>(this.baseUrl + "getOverviewOfImplementationOfIndicators/" + actionPlanId);
  }

  getOverviewOfImplementationOfMeasurePerObjectiveSpecific(actionPlanId: string): Observable<ImplementationOfMeasurePerObjectiveViewModel[]> {
    return this.httpClient.get<ImplementationOfMeasurePerObjectiveViewModel[]>(this.baseUrl + "getOverviewOfImplementationOfMeasurePerObjectiveSpecific/" + actionPlanId, {});
  }

  getOverviewOfImplementationOfMeasures(actionPlanId: string): Observable<ImplementationPieChartViewModel> {
    return this.httpClient.get<ImplementationPieChartViewModel>(this.baseUrl + "getOverviewOfImplementationOfMeasures/" + actionPlanId);
  }

  getStatisticOfPlans(actionPlanId: string): Observable<StatisticOfPlanViewModel> {
    return this.httpClient.get<StatisticOfPlanViewModel>(this.baseUrl + "getStatisticOfPlans/" + actionPlanId);
  }
}
