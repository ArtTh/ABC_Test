export class Location {
  public constructor(init?: Partial<Location>) {
    Object.assign(this, init);
  }

  name: string;
  address: string;
  longitude: number;
  latitude: number;
  cityId: number;
}
