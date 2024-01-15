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
        self.notify("Thread started its execution")

    def put_to_sleep(self):
        self.status = "Sleeping"
        self.notify("Thread has been put to sleep")

    def abort_execution(self):
        self.status = "Aborted"
        self.notify("Thread execution aborted")

class Observer(ThreadObserver):
    def update(self, thread, message):
        print(f"Observer received: Thread {thread.id} - {message}")

thread_instance = Thread(1, 0)
observer_instance = Observer()

thread_instance.subscribe(observer_instance)

thread_instance.start_execution()
thread_instance.put_to_sleep()
thread_instance.abort_execution()

thread_instance.unsubscribe(observer_instance)
