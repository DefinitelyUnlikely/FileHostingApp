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
    public files: FileMetadata[]

    public constructor(id: string, name: string, subFolders: Folder[], files: FileMetadata[], userId: string) {
        this.id = id;
        this.name = name;
        this.subFolders = subFolders;
        this.files = files
        this.userid = userId;
    }
}

export class FileMetadata {
    public name: string;

    public constructor(name: string) {
        this.name = name;
    }

}

export class FileData {

}