import { IFileManagement } from "./IFileManagement";

export interface IFileManagementPaginator {
  totalRecords: number;
  itemCount: number;
  pageSize: number;
  totalPages: number;
  pageNumber: number;
  firstPage: string;
  previousPage: string;
  nextPage: string;
  lastPage: string;
  data: IFileManagement[];
}
