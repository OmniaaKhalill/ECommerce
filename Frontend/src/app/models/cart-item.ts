export class CartItem {
  


    constructor(
       public id:number,
       public quantity:number,
       public price:number,
       public colors: { colour_name: string, hex_value: string },
    ){}


}
