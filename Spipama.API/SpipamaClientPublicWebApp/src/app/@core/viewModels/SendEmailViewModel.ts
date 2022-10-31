export class SendEmailViewModel {
  name: string;
  surname: string;
  email: string;
  message: string;

  constructor(
    name: string = null,
    surname: string = null,
    email: string = null,
    message: string = null,
  ) {
    this.name = name;
    this.surname = surname;
    this.email = email;
    this.message = message;
  }
}
