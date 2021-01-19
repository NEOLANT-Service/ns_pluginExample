export class Identity implements IIdentity {
  constructor(public id: string, public name: string, public roles: string[]) {}
}

export interface IIdentity {
  readonly id: string;
  readonly name: string;
  readonly roles: string[];
  // privileges
  // permissions
}
