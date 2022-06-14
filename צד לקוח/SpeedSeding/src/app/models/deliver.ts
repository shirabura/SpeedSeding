import { Time } from "@angular/common"

export interface deliver{
    DELIVERID :number;
    IDOFDELIVER :number;
    IDOFCUSTUMER:number;
    DATE :Date;
    RESPOND :Boolean;
    SOURSEADRESS :string;
    DESTINATIONADRESS:string;
    DONE: Boolean;
    HOUR :Time;

}