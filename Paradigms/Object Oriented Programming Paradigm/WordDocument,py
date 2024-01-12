from abc import ABC, abstractmethod

class DocumentPart(ABC):
    # def __init__ (self, content):
    #     self.name = content[0]
    #     self.position = content[1]
    
    @abstractmethod
    def paint(self):
        pass
    @abstractmethod
    def save(self):
        pass

    
class Header(DocumentPart):
    def paint(self):
        print("Painting Header")
    def save(self):
        print("Saving Header")
        
class Paragraph(DocumentPart):
    def paint(self):
        print("Painting Paragraph")
    def save(self):
        print("Saving Paragraph")

class HyperLink(DocumentPart):
    def paint(self):
        print("Painting HyperLink")
    def save(self):
        print("Saving HyperLink")

class Footer(DocumentPart):
    def paint(self):
        print("Painting Footer")
    def save(self):
        print("Saving Footer")

class WordDocument:
    def __init__(self, array_document_parts):
        self.document_parts = array_document_parts
 
    def add_document_part(self, document_part):
        self.document_parts.append(document_part)
 
    def paint_all(self):
        for part in self.document_parts:
            part.paint()
 
    def save_all(self):
        for part in self.document_parts:
            part.save()
            
def main():
    header = Header()
    footer = Footer()
    hyperlink = HyperLink()
    paragraph = Paragraph()
    
    word_doc = WordDocument([header, footer, hyperlink, paragraph])
 
    word_doc.paint_all()
    word_doc.save_all()
    
if __name__ == "__main__":
    main()
