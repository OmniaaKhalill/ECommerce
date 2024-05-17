export class ProductRead {


    public id:number=0;
    public name: string="";
    public brand: string="";
    public category: string="";
    public price: number=0
    public colors: { colour_name: string, hex_value: string }[]=[]
    public numOfProductInStock: number=0;
    public image_link:string=""
    public description:string=""
}
