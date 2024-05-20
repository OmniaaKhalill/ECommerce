import { ShippingAddress } from "./shipping-address";

export class Order {

  
    constructor(
        public buyerEmail: string,
        public cartId: string,
        public shippingAddress:ShippingAddress
    ) {}
}
