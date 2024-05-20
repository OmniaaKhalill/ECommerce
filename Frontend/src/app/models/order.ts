import { shippingAddress } from "./shipping-address";

export class order {

  
    constructor(
        public buyerEmail: string,
        public cartId: string,
        public shippingAddress:shippingAddress
    ) {}
}
