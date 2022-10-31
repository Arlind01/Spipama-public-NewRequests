import { ReportImplementationViewModel } from "../viewModels/ReportImplementationViewModel";

export interface IReportImplementation {
  totalRecords: number;
  itemCount: number;
  pageSize: number;
  totalPages: number;
  pageNumber: number;
  firstPage: string;
  previousPage: string;
  nextPage: string;
  lastPage: string;
  data: ReportImplementationViewModel[];
}
