namespace PersonInfo
{
    //Convention -> Most of the interfaces should be public
    //Define public side of our class: properties (getter, setter), methods
    public interface IPerson
    {
        //Define public structure of the class
        string Name { get; }

        int Age { get; }
    }
}
