import { NewsViewModel } from "../viewModels/NewsViewModel";

export interface INewsPage {
  totalRecords: number;
  itemCount: number;
  pageSize: number;
  totalPages: number;
  pageNumber: number;
  firstPage: string;
  previousPage: string;
  nextPage: string;
  lastPage: string;
  data: NewsViewModel[];
}
