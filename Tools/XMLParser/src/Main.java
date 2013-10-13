import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class Main {

    public static void main(String[] args) throws IOException{
        BufferedReader br = new BufferedReader(new FileReader("C:\\Users\\Tom\\IdeaProjects\\XMLParser\\src\\top250.xml"));
        StringBuilder sb = null;
        try {
            sb = new StringBuilder();
            String line = br.readLine();

            while (line != null) {
                if(!line.isEmpty()){
                    sb.append(getValue(line,"name"));
                    sb.append(",");
                    sb.append(getValue(line,"coordinates").split(",0")[0]);
                    sb.append(",");
                    sb.append(getValue(line,"address").replace(",",""));
                    sb.append("\r\n");
                }

                line = br.readLine();
            }
        }finally {
            br.close();
        }
        System.out.println(sb.toString());
    }

    private static String getValue(String line,String value){
        int beginIndex = line.indexOf(value+">")+value.length()+1;
        int endIndex = line.indexOf("</"+value);

        return line.substring(beginIndex,endIndex);
    }
}
