internal class number_operations
{
    private static void Main(string[] args)
    {
        // ValueType = Number
        List<ValueType> number_list = [10, 20.5, 30, 40.7, 50, 60.3, 70, 80.1, 90, 100.9];
        int integer_num = 1441;
        long long_num = long.MaxValue;
        double double_num = 123.0;
        float float_num = 9.11f;
        number_list.Add(integer_num);
        number_list.Add(long_num);
        number_list.Add(double_num);
        number_list.Add(float_num);
        


        // Console.Write("Whole list: [ ");
        // foreach (ValueType x in number_list) {
        //     Console.Write(x + "; ");
        // }
        Console.WriteLine("Whole List: " + TransformList(number_list, (ValueType x) => x.ToString()));
        
        // Console.Write("]\n\nList rounded to ints: [ ");
        // foreach (ValueType x in number_list) {
        //     Console.Write(Convert.ToInt64(x) + "; ");
        // }
        Console.WriteLine("List rounded to ints: " + TransformList(number_list, (x)=> Convert.ToInt64(x).ToString()));

        // Console.Write("]\n\nList formatted to 2 decimals: [ ");
        // foreach (ValueType x in number_list) {
        //     Console.Write(Convert.ToDecimal(x).ToString("0.00") + "; ");
        // }
        Console.WriteLine("List formatted to 2 decimals: " + TransformList(number_list,(x) => Convert.ToDecimal(x).ToString("0.00")));

        // Console.Write("]\n\n");
        Dictionary<Type, List<ValueType>> num_lists = new Dictionary<Type, List<ValueType>>();
        foreach (ValueType x in number_list)
        {
            if (!num_lists.ContainsKey(x.GetType()))
                num_lists.Add(x.GetType(), []);
            num_lists[x.GetType()].Add(x);
        }

        foreach (KeyValuePair<Type, List<ValueType>> x in num_lists)
        {
            // Console.Write(x.Key.ToString().Split(".").Last() + " list: [ ");
            // x.Value.ForEach((ValueType x) => {Console.Write(x + "; ");});
            // Console.WriteLine("]");
            Console.Write(x.Key.ToString().Split(".").Last() + " list: " + TransformList(x.Value,(y) => y.ToString()) + "\n");
        }


        // Console.Write("\nIntegers: [ ");
        List<ValueType> integers = new List<ValueType>();
        foreach(ValueType x in number_list) {
            if(Convert.ToDecimal(x) % 1 == 0){
                integers.Add(x);
            }
        }
        // integers.ForEach((ValueType x) => {Console.Write(x+"; ");});
        // Console.WriteLine("]");
        Console.WriteLine("Integers: " + TransformList(integers,(x) => x.ToString()));
    }

    public static string TransformList(List<ValueType> list,Func<ValueType,string> func) {
        string res = "[";
        foreach(ValueType num in list) {
            res += func(num) + "; ";
        }
        return string.Join("",res.Take(res.Length - 2)) + "]";
    }

}
