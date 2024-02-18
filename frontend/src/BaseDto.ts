export class BaseDto<T>{
  eventType: string;

  constructor(init?: Partial<T>) {
    this.eventType = this.constructor.name;
    Object.assign(this, init)
  }

}

export class ServerEchoesClientDto extends BaseDto<ServerEchoesClientDto>{
  echoValue?: string;
};
