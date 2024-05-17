export class Product {
    constructor(
        public id:number,
        public name: string,
        public categoryId: number,
        public price: number,
        public colors: { colour_name: string, hex_value: string }[],
        public numOfProductInStock: number,
        public image_link:string,
        public description:string,
        public reviews:{content:string , rating:number ,datePosted:Date,userId:string ,displayName:string}[],
        public category: string,
        public brandsid: number,
        public brands: string,
       
        
    ) {}
}
