export class Product {
    constructor(
        public Name: string,
        public Brand: string,
        public Category: string,
        public Price: number,
        public Colors: { name: string, hexVal: string }[],
        public Tags: string[],
        public NumOfProductInStock: number,
        public ImageLink:string,
        public Description:string,
        
    ) {}
}
