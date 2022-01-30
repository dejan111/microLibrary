export interface LibraryUser {
    id?: number | null,
    libraryId?: number | null,
    firstName: string,
    lastName: string,
    oib: string,
    postalCode: string,
    address: string,
    city: string,
    dateOfBirth?: Date |null,
    active: boolean,
    libraryUserContacts?: LibraryUserContact[] | []
}

export interface LibraryUserContact {
    id?: number |null,
    libraryUserId: number,
    contactTypeId: number,
    contactTypeName: string,
    contact: string,
    description: string
}