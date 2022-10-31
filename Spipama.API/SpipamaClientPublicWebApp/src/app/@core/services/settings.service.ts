import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IPublicCodes } from '../interfaces/IPublicCodes';
import { DocumentsDTOViewModel } from '../viewModels/DocumentsDTOViewModel';
import { SendEmailViewModel } from '../viewModels/SendEmailViewModel';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  baseUrl = environment.apiEndpoint + 'api/Settings/';
  baseUrlContact = environment.apiEndpoint + 'api/Contact/';

  downloadDoc(path: string): Observable<any> {
    let params = new HttpParams();
    params = params.append("path", path);
    return this.httpClient.get(this.baseUrl + "downloadDoc", { params: params, responseType: 'blob' as 'json' });
  }

  downloadStaticDoc(path: string): Observable<any> {
    let params = new HttpParams();
    params = params.append("path", path);
    return this.httpClient.get(this.baseUrl + "downloadStaticDoc", { params: params, responseType: 'blob' as 'json' });
  }

  getGVRAPConclusions(): Observable<DocumentsDTOViewModel[]> {
    return this.httpClient.get<DocumentsDTOViewModel[]>(this.baseUrl + "getGVRAPConclusions");
  }

  getKMRAPConclusions(): Observable<DocumentsDTOViewModel[]> {
    return this.httpClient.get<DocumentsDTOViewModel[]>(this.baseUrl + "getKMRAPConclusions");
  }

  getRAPStrategies(): Observable<DocumentsDTOViewModel[]> {
    return this.httpClient.get<DocumentsDTOViewModel[]>(this.baseUrl + "getRAPStrategies");
  }

  getRAPImplementationReports(): Observable<DocumentsDTOViewModel[]> {
    return this.httpClient.get<DocumentsDTOViewModel[]>(this.baseUrl + "getRAPImplementationReports");
  }

  getPublicCodes(language): Observable<IPublicCodes[]> {
    return this.httpClient.get<IPublicCodes[]>(this.baseUrl + "publicCodes/" + language);
  }

  getGovernmentProgram(): Observable<DocumentsDTOViewModel[]> {
    return this.httpClient.get<DocumentsDTOViewModel[]>(this.baseUrl + "getGovernmentProgram");
  }

  sendEmail(obj: SendEmailViewModel): Observable<SendEmailViewModel> {
    return this.httpClient.post<SendEmailViewModel>(this.baseUrlContact + "sendEmail", obj);
  }
}
