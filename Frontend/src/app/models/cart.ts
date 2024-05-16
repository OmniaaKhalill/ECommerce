import { CartItem } from "./cart-item";

export class Cart 
{
    id:string="";
    items:CartItem[]=[];
    paymentIntentId:string|null=null;
    clientSecret:string|null=null;
}
