export class CartItem {
  


    constructor(
       public id:number=0,
       public quantity:number=0,
       public price:number=0,
       public colors: { colour_name: string, hex_value: string },
    ){}


}
