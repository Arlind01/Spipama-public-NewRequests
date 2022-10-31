export class DocumentsDTOViewModel {
  fileName: string;
  fileRef: string;
  isPDF?: boolean = false;

  constructor
    (
    fileName: string = null,
    fileRef: string = null,
    isPDF: boolean = null,
    ) {
    this.fileName = fileName;
    this.fileRef = fileRef;
    this.isPDF = isPDF;
    }
}
