import random

class ThreadObserver:
    def update(self, thread, message):
        pass

class Thread:
    def __init__(self, id, priority):
        global COUNTER
        self.id = id
        self.priority = priority
        self.status = "Created"
        self.observers = []

    def subscribe(self, observer):
        self.observers.append(observer)

    def unsubscribe(self, observer):
        self.observers.remove(observer)

    def notify(self, message):
        for observer in self.observers:
            observer.update(self, message)

    def start_execution(self):
        self.status = "Running"
        self.notify(self.status)

    def put_to_sleep(self):
        self.status = "Sleeping"
        self.notify(self.status)

    def abort_execution(self):
        self.status = "Aborted"
        self.notify(self.status)

class Observer(ThreadObserver):
    def update(self, thread, message):
        thread_status = message

thread_instance = Thread(1, 0)
observer_instance = Observer()

thread_instance.subscribe(observer_instance)

thread_instance.start_execution()
thread_instance.put_to_sleep()
thread_instance.abort_execution()

thread_instance.unsubscribe(observer_instance)
