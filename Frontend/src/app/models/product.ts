export class Product {
  constructor(
      public name: string,
      public brand: string,
      public categoryId: number,
      public category: string,
      public price: number,
      public colors: { colour_name: string, hex_value: string }[],
      public numOfProductInStock: number,
      public image_link:string,
      public description:string,
      public sellerId:number
  ) {}
}