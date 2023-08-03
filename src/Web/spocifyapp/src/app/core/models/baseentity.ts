export interface IBaseEntity {
    id: string;
    createdOn: Date | string;
    updateOn: Date | string;
    state: number;
}