export class LocationEdit {
  public constructor(init?: Partial<LocationEdit>) {
    Object.assign(this, init);
  }

  name: string;
  address: string;
  longitude: number;
  latitude: number;
  city: number;
}
