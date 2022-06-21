import { Time } from "@angular/common";

export class possibledrive {
    constructor(
        public IDOFDELIVER?: number,
        public DATE?: Date,
        public HOUR?: Time,
        public SOURSEADRESS?: string,
        public DESTINATIONADRESS?: string
    ) { }
}