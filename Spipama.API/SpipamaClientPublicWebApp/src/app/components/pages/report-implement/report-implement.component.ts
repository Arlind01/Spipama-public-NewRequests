import { Component, OnInit } from '@angular/core';
import { IReportImplementation } from '../../../@core/interfaces/IReportImplementation';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ReportImplemenationService } from '../../../@core/services/report-implement.service';
import { MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { TranslateService } from '@ngx-translate/core';
import { IFileManagementPaginator } from '../../../@core/interfaces/IFileManagementPaginator';
import { IFileCategories } from '../../../@core/interfaces/IFileCategories';
import { FileManagementService } from '../../../@core/services/file-management.service';
import { SettingsService } from '../../../@core/services/settings.service';
import { IPublicCodes } from '../../../@core/interfaces/IPublicCodes';


@Component({
  selector: 'app-report-implement',
  templateUrl: './report-implement.component.html',
  styleUrls: ['./report-implement.component.scss']
})
export class ReportImplementComponent implements OnInit {

  dataSource: IFileManagementPaginator;
  displayedColumns: string[] = ['fileName', 'showFile', 'delete'];
  length = 5;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  isSuccess: string = "";
  loading = true;
  selectedFileCategory: string;
  filterSelectObj = [];
  optionsFileCategories: IFileCategories[];
  codes: IPublicCodes[];


  constructor(private router: Router, private reportsService: ReportImplemenationService, public _MatPaginatorIntl: MatPaginatorIntl, private translate: TranslateService, private fileManagementService: FileManagementService, private settingsService: SettingsService) {
    translate.setDefaultLang('al');
  }

  ngOnInit(): void {
    this._MatPaginatorIntl.itemsPerPageLabel = this.translate['reportsHome.reportPerPage'];
    this.fileManagementService.isSuccess.subscribe(message => this.isSuccess = message);
    if (this.isSuccess != "") {
      this.fileManagementService.changeIsSuccess("");
    }
    this.selectedFileCategory = "0ee46f80-eeb5-4e2b-b415-a04b98322c1e";
    this.getFilesManagement();
    this.getOptionsFileCategories();
    this.setText();
  }

  setText() {
    this.settingsService.getPublicCodes('al').subscribe(x => { this.codes = x; localStorage.setItem('codes', JSON.stringify(x));});
  }

  getTextId(id): string {
    return this.codes.find(x => x.id == id).name;
  }

  useLanguage(language: string): void {
    this.translate.use(language);
  }

  getFilesManagement() {
    this.fileManagementService.getFilesManagement(1, 10, this.selectedFileCategory).subscribe(res => { this.dataSource = res;this.loading = false; });
  }

  getOptionsFileCategories() {
    this.fileManagementService.getFileCategories().subscribe(response => {
      this.optionsFileCategories = response;
      this.filterSelectObj = [
        {
          name: 'Categories',
          columnProp: 'Categories',
          options: this.optionsFileCategories
        }
      ]
    });
  }

  filterChange(filter, event) {
    this.selectedFileCategory = event.target.value;
    this.dataSource = null;
    this.fileManagementService.getFilesManagement(1, 10, this.selectedFileCategory).subscribe(res => { this.dataSource = res });
  }

  onPaginateChange(event: PageEvent) 
    {
      this.length = event.length;
      this.pageSize = event.pageSize;
      this.pageIndex = event.pageIndex + 1;

      this.fileManagementService.getFilesManagement(this.pageIndex, this.pageSize, this.selectedFileCategory).subscribe(res => { this.dataSource = res; this.loading = false; });
    }

  routeToReports(id) {
    this.router.navigate(['/report/' + id]);
  }

  getInnerText(el) {
    return el.innerText;
  }
}
