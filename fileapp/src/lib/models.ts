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
    public id: string;
    public name: string;
    public extension: string;
    public createdAt: Date;
    public updatedAt: Date;
    public folderId: string;
    public userId: string;

    public constructor(id: string, name: string, extension: string, createdAt: Date, updatedAt: Date, folderId: string, userId: string) {
        this.id = id;
        this.name = name;
        this.extension = extension;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
        this.folderId = folderId;
        this.userId = userId;
    }

}

export class FileData {

}