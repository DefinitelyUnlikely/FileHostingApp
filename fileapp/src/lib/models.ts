export class User {
    public email: string;

    public constructor(email: string) {
        this.email = email;
    }
}

export class Folder {
    public id: string
    public name: string
    public subFolders: Folder[]
    public userid: string // Might be superfluous

    public constructor(id: string, name: string, subFolders: Folder[], userId: string) {
        this.id = id;
        this.name = name;
        this.subFolders = subFolders;
        this.userid = userId;
    }
}

export class FileMetadata {

}

export class FileData {

}