from abc import ABC, abstractmethod

class DocumentPart(ABC):
    _name = ''
    _position = ''
    
    @abstractmethod
    def paint(self):
        pass
    
    @abstractmethod
    def convert(self, converterClass):
        pass
 
    @abstractmethod
    def save(self):
        pass
    
class Header(DocumentPart):
    def __init__(self, title =  "DefaultTitle"):
        self.title = title
    def paint(self):
        print("Painting Header titled", self.title)
 
    def save(self):
        print("Saving Header")
        
    def convert(self, converterClass):
        converterClass.convertHeader(self)
        pass
 
class Footer(DocumentPart):
    def __init__(self, text =  "DefaultText"):
        self.text = text
        
    def paint(self):
        print("Painting Footer having text", self.text)
 
    def save(self):
        print("Saving Footer")
        
    def convert(self, converterClass):
        converterClass.convertFooter(self)
        pass
 
class Hyperlink(DocumentPart):
    def __init__(self,url = "defaultURL.com", text = "defaultText"):
        self.url = url
        self.text = text
    
    def paint(self, ):
        print("Painting Hyperlink having url {} and text {}".format(self.url, self.text))
 
    def save(self):
        print("Saving Hyperlink")
        
    def convert(self, converterClass):
        converterClass.convertHyperLink(self)
        pass
 
class Paragraph(DocumentPart):
    def __init__(self, content = "defaultContent"):
        self.content = content
        
    def paint(self):
        print("Painting Paragraph having content", self.content)
 
    def save(self):
        print("Saving Paragraph")
        
    def convert(self, converterClass):
        converterClass.convertPara(self)
        pass 

class ConverterInterface(ABC):
    
    @abstractmethod
    def convertHeader(self, header : Header):
        pass
    
    @abstractmethod
    def convertFooter(self, footer : Footer):
        pass
    
    @abstractmethod
    def convertHyperLink(self, hyperlink : Hyperlink):
        pass
    
    @abstractmethod
    def convertPara(self, paragraph : Paragraph):
        pass
    
class HTMLConverter(ConverterInterface):
    def convertHeader(self, header):
        print("Header Converted")
        
    def convertFooter(self, footer):
        print("Footer Converted")
    
    def convertHyperLink(self, hyperlink):
        print("HyperLink Converted")
    
    def convertPara(self, paragraph):
        print("Paragraph Converted")
    
class WordDocument:
    def __init__(self, documentParts=[]):
        self.documentParts = documentParts
        
    def addDocumentPart(self, documentPart):
        self.documentParts.append(documentPart)
 
    def openDocument(self):
        for part in self.documentParts:
            part.paint()
 
    def saveDocument(self):
        for part in self.documentParts:
            part.save()
            
    def transform(self, converterObject):
        for documentPart in self.documentParts:
            documentPart.convert(converterObject)
            
def main():
    headerObj = Header("Title1")
    hyperlinkObj = Hyperlink("google.co.in", "search")
    footerObj = Footer()
    paragraphObj = Paragraph()
     
    wordDoc = WordDocument([headerObj, footerObj, hyperlinkObj, paragraphObj])
    HTMLConverterObj = HTMLConverter()
    
    wordDoc.openDocument()
    wordDoc.saveDocument()
    wordDoc.transform(HTMLConverterObj)
    
if __name__ == main:
    main()
