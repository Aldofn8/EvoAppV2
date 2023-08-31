export interface CustomerModel {
    customerId: number,
    name: string,
    surname: string,
    dni: number,
    birthDate: Date,
    phone: number,
    email: string,
    password: string,
    clientState: boolean,
    clientVerify: boolean
}