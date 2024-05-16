export class Product {
    constructor(
        public id:number,
        public name: string,
        public brand: string,
        public categoryId: number,
        public price: number,
        public colors: { colour_name: string, hex_value: string }[],
        public numOfProductInStock: number,
        public image_link:string,
        public description:string,
        public sellerId:number,
        public reviews:{content:string , rating:number ,datePosted:Date,userId:string ,displayName:string}[]
        
    ) {}
}
