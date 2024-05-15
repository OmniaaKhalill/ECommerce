export class Product {
  constructor(
      public name: string,
      public brandsid: number,
      public brands: string,
      public categoryId: number,
      public category: string,
      public price: number,
      public colors: { id: number, hexValue: string, colourName: string }[],
      public numOfProductInStock: number,
      public image_link:string,
      public description:string,
      public sellerId:number
  ) {}
}
