import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { IFileCategories } from '../interfaces/IFileCategories';
import { IFileManagement } from '../interfaces/IFileManagement';
import { IFileManagementPaginator } from '../interfaces/IFileManagementPaginator';

@Injectable({
  providedIn: 'root'
})
export class FileManagementService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  baseUrl = environment.apiEndpoint + 'api/fileManagement/';
  file: any;

  private isSuccessSource = new BehaviorSubject<string>("");
  isSuccess = this.isSuccessSource.asObservable();

  getFilesManagement(page, size, categoryId) {
    let params = new HttpParams();

    params = params.append('PageNumber', String(page));
    params = params.append('PageSize', String(size));
    params = params.append('CategoryId', String(categoryId));

    return this.httpClient.get<IFileManagementPaginator>(this.baseUrl + "getFilesManagement?" + params);
  }

  getFilesManagementById(id) {
    return this.httpClient.get<IFileManagement>(this.baseUrl + "getFileManagementById/" + id);
  }

  getFileCategories() {
    return this.httpClient.get<IFileCategories[]>(this.baseUrl + "getFilesCategory");
  }

  changeIsSuccess(value: string) {
    this.isSuccessSource.next(value);
  }

}
