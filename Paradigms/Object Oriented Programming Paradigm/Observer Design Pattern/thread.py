import random

COUNTER = 0
PRIORITY = [0, 1, 2, 3, 4, 5]

class ThreadObserver:
    def update(self, thread, message):
        pass

class Thread:
    def __init__(self):
        global COUNTER
        self.id = COUNTER + 1
        COUNTER += 1

        global PRIORITY
        self.priority = random.choice(PRIORITY)
        PRIORITY.remove(self.priority)

        self.status = "Created"
        print("Thread Created")
        print(self.priority)
        
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
        print("Thread started its execution")

    def put_to_sleep(self):
        self.status = "Sleeping"
        self.notify("Thread has been put to sleep")
        print("Thread has been put to sleep")

    def abort_execution(self):
        self.status = "Aborted"
        self.notify("Thread execution aborted")
        print("Thread execution aborted")

class Observer(ThreadObserver):
    def update(self, thread, message):
        print(f"Observer received: Thread {thread.id} - {message}")

thread_instance = Thread()
observer_instance = Observer()

thread_instance.subscribe(observer_instance)

thread_instance.start_execution()
thread_instance.put_to_sleep()
thread_instance.abort_execution()

thread_instance.unsubscribe(observer_instance)
