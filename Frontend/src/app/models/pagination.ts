import { Product } from "./product"

export class Pagination {
  constructor(
    public PageIndex: number,
    public PageSize: number,
    public Count: number,
    public Data: Product[],
  ) {}
}
/*
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }
*/