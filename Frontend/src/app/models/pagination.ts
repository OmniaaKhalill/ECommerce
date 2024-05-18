import { Product } from "./product"
export class Pagination {
  constructor(
    public PageIndex: number = 1,
    public PageSize: number = 5,
    public Count: number = 0,
    public Data: Product[] = []
  ) {}
}
