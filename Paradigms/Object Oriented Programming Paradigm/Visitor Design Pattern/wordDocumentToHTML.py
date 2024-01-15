from abc import ABC, abstractmethod

class DocumentPart(ABC):
    def __init__(self):
        self.name = ""
        self.position = ""

    @abstractmethod
    def paint(self):
        pass

    @abstractmethod
    def save(self):
        pass

    @abstractmethod
    def convert(self, i_converter):
        pass

class Header(DocumentPart):
    def __init__(self):
        super()._init_()
        self.title = ""

    def paint(self):
        print("Painted Header")

    def save(self):
        print("Saved Header")

    def convert(self, i_converter):
        i_converter.convert(self)

class Paragraph(DocumentPart):
    def __init__(self):
        super()._init_()
        self.content = ""
        self.lines = ""

    def paint(self):
        print("Painted Paragraph")

    def save(self):
        print("Saved Paragraph")

    def convert(self, i_converter):
        i_converter.convert(self)

class HyperLink(DocumentPart):
    def __init__(self):
        super()._init_()
        self.url = ""
        self.text = ""

    def paint(self):
        print("Painted Hyper Link")

    def save(self):
        print("Saved Hyper Link")

    def convert(self, i_converter):
        i_converter.convert(self)

class Footer(DocumentPart):
    def __init__(self):
        super()._init_()
        self.text = ""

    def paint(self):
        print("Painted Footer")

    def save(self):
        print("Saved Footer")

    def convert(self, i_converter):
        i_converter.convert(self)

class WordDocument:
    def __init__(self, document_part_list):
        self.document_parts = document_part_list

    def open(self):
        for part_item in self.document_parts:
            part_item.paint()
            part_item.save()

    def convert(self, i_converter):
        for part_item in self.document_parts:
            part_item.convert(i_converter)

class ConverterInterface(ABC):
    @abstractmethod
    def convert(self, header_item):
        pass

    @abstractmethod
    def convert(self, paragraph_item):
        pass

    @abstractmethod
    def convert(self, hyperlink_item):
        pass

    @abstractmethod
    def convert(self, footer_item):
        pass

class HTMLConverter(ConverterInterface):
    def convert(self, header_item):
        print("header converted")

    def convert(self, paragraph_item):
        print("paragraph converted")

    def convert(self, hyperlink_item):
        print("hyperlink converted")

    def convert(self, footer_item):
        print("footer converted")

if __name__ == "_main_":
    header1 = Header()
    paragraph1 = Paragraph()
    hyperlink1 = HyperLink()
    footer1 = Footer()

    document_part_list = [header1, paragraph1, hyperlink1, footer1]
    word_document1 = WordDocument(document_part_list)
    html_converter = HTMLConverter()

    word_document1.convert(html_converter)
