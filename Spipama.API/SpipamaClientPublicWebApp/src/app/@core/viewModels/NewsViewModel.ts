export class NewsViewModel {
  title: string;
  description: string;
  imageUrl: string;
  dateEvent: Date;
  createdOn: Date;

  constructor(
    title: string = null,
    description: string = null,
    imageUrl: string = null,
    dateEvent: Date = null,
    createdOn: Date = null,
  ) {
      this.title = title;
      this.description = description;
      this.imageUrl = imageUrl;
      this.dateEvent = dateEvent;
      this.createdOn = createdOn;
  }
}
